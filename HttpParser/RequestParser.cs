using System;
using System.Collections.Generic;

namespace HttpParser
{
    class RequestParser
    {
        private string _httpMethod = string.Empty;
        private string _urlPath = string.Empty;
        private string _httpVersion = string.Empty;
        private Dictionary<string, string> _requestKeyValuePair = new Dictionary<string, string>();
        public void ParseRequestData(string[] requestData)
        {
            var sequenceOfLine = 1;
            var requestLine = requestData[0];
            var requestParameter = requestLine.Split(' ');
            _httpMethod = requestParameter[0];
            _urlPath = requestParameter[1];
            _httpVersion = requestParameter[2];
            while(!requestData[sequenceOfLine].Equals(string.Empty))
            {
                var indexWhereToSplit = requestData[sequenceOfLine].IndexOf(':');
                var httpAttributeName = requestData[sequenceOfLine].Substring(0, indexWhereToSplit);
                var httpAttributeValue = requestData[sequenceOfLine].Substring(indexWhereToSplit+2);
                _requestKeyValuePair.Add(httpAttributeName,httpAttributeValue);
                sequenceOfLine++;
            }
            var message = string.Empty;
            while(sequenceOfLine<requestData.Length)
            {
                message = message + requestData[sequenceOfLine] + "\n";
                sequenceOfLine++;
            }
            _requestKeyValuePair.Add("RequestMessageBody", message);
        }

        public void GetParsedRequest()
        {
            Console.WriteLine("Http Request Attribute :");
            Console.WriteLine($"Http Method: {_httpMethod}");
            Console.WriteLine($"Url Path: {_urlPath}");
            Console.WriteLine($"Http Version: {_urlPath}");
            foreach (var keys in _requestKeyValuePair.Keys)
            {
                Console.WriteLine($"{keys} : {_requestKeyValuePair[keys]}");
            }
        }
    }
}
