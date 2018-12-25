using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (JavascriptContext context = new JavascriptContext())
            {

                // Setting external parameters for the context
                context.SetParameter("console", new SystemConsole());
                //context.SetParameter("message", "Hello World !");
                //context.SetParameter("number", 1);

                // Script
                string script = @"
var parseJson = function(str) {
    if (typeof JSON !== 'undefined') {
        return JSON.parse(str);
    }
    var res = new Function('return ' + str);
    return res();
}
var stringifyJSON = function(obj) {
    var type = typeof obj;
    if (obj == null) {
        return 'null';
    }
    if (type == 'string') {
        return '\'' + obj.replace(/([\'\'\\])/g, '\\$1').replace(/\t/g, '\\t').replace(/\n/g, '\\n').replace(/\f/g, '\\f').replace(/\r/g, '\\r') + '\'';
    }
    if (type == 'number') {
        return obj.toString();
    }
    if (type == 'boolean') {
        return obj + '';
    }
    if (Object.prototype.toString.call(obj) == '[object Date]') {
        return obj.format('YYYY-MM-DD hh:mm:ss');
    }
    var r = [],
        i, x;
    if (Object.prototype.toString.call(obj) == '[object Array]') {
        var il = obj.length;
        for (i = 0; i < il; i += 1) {
            x = arguments.callee(obj[i]);
            x != null && r.push(x);
        }
        return '[' + r.join(',') + ']';
    }
    if (obj && obj.constructor == Object) {
        for (i in obj) {
            x = arguments.callee(obj[i]);
            x != null && r.push('\'' + i + '\':' + x);
        }
        return '{' + r.join(',') + '}';
    }
    return null;
};

function getSearch(url) {
    var a = '';
    if (url) {
        var reg = /(\?.+)/;
        var matches = url.match(reg);
        if (matches) {
            a = matches[1];
        }
    } else {
        a = 'https://sso.woniu.com/login'.search;
    }
    if (!a) {
        return {};
    }
    var obj = {};
    var ps = a.substr(1, a.length).split('&')
    for (var i = 0; i < ps.length; i++) {
        var _a = ps[i].split('=');
        var k = _a[0],
            v = _a[1];
        if (obj[k]) {
            obj[k] = [obj[k]];
            obj[k].push(v);
        } else {
            obj[k] = v;
        }
    }
    return obj;
}

function createVerParams(url, params) {
    var paramsStr = [];
    var stringifyParams = stringifyJSON(params);
    paramsStr.push(stringifyParams);

    /* var access = {
        accessId: 2010,
        accessType: 8,
        accessKey: 'grssiAYYUjvRPUV',
        accessPasswd: 'v2fz2wN8hnPqB3'
    } */
    var access = {
        accessId: 351,
        accessType: 6,
        accessKey: 'bhiUcI3v5B1Y',
        accessPasswd: 'lMBrqsr6uA6o6GoS'
    }

    var reg = /[https,http]:\/\/[^/]+(\/[^?]+)\?*/;
    var matches = url.match(reg);
    var uri = url;
    if (matches) {
        uri = matches[1];
    }
    paramsStr.push(uri);
    var temp = {};
    temp.signVersion = '1.0';
    temp.second = parseInt((new Date().getTime()) / 1000);
    var search = getSearch(url);
    for (var p in search) {
        temp[p] = search[p];
    }

    for (var p in access) {
        temp[p] = access[p];
    }

    paramsStr.push(access.accessId);
    paramsStr.push(access.accessPasswd);
    paramsStr.push(access.accessType);
    paramsStr.push(temp.second);
    paramsStr.push(temp.signVersion);

    paramsStr.push(access.accessKey);
    temp.postBody = stringifyParams;

    temp.accessVerify = md5(paramsStr.join(''));

    delete temp.accessKey;
    return temp;
}
jsUrl = '';
params = {};
function captcha(captchaInUrl) {
    jsUrl = 'https://cloud.api.woniu.com/cloud/captcha/genkey/' + captchaInUrl;

    params = createVerParams(jsUrl, {
        file: 'captcha_generation.js'
    });
    
    
}
console.log(jsUrl);
function md5(str){return 1;};
captcha('111111')
";
                //script = script.Replace("\u0065\u0076\u0061\u006c", "a=");

                // Running the script
                context.Run(script);

                // Getting a parameter
                Console.WriteLine("number: " + context.GetParameter("jsUrl"));
               
                Console.ReadKey();
            }
        }
        public class SystemConsole
        {
            public SystemConsole() { }

            public void Print(string iString)
            {
                Console.WriteLine(iString);
            }
        }
    }
}
