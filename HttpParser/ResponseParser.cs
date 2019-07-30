using System;
using System.Collections.Generic;

namespace HttpParser
{
    class ResponseParser
    {
        private string _httpVersion = string.Empty;
        private string _statusCode = string.Empty;
        private string _statusReasonPhrase = string.Empty;
        private Dictionary<string, string> _responseKeyValuePair = new Dictionary<string, string>();
        public void ParseResponseData(string[] responseData)
        {
            var sequenceOfLine = 1;
            var requestLine = responseData[0];
            var responseParameter = requestLine.Split(' ');
            _httpVersion = responseParameter[0];
            _statusCode = responseParameter[1];
            _statusReasonPhrase = responseParameter[2];
            while (!responseData[sequenceOfLine].Equals(string.Empty))
            {
                var indexWhereToSplit = responseData[sequenceOfLine].IndexOf(':');
                var httpAttributeName = responseData[sequenceOfLine].Substring(0, indexWhereToSplit);
                var httpAttributeValue = responseData[sequenceOfLine].Substring(indexWhereToSplit+2);
                _responseKeyValuePair.Add(httpAttributeName, httpAttributeValue);
                sequenceOfLine++;
            }
            var message = string.Empty;
            while (sequenceOfLine < responseData.Length)
            {
                message = message + responseData[sequenceOfLine] + "\n";
                sequenceOfLine++;
            }
            _responseKeyValuePair.Add("ResponseMessageBody", message);
        }

        public void DisplayParsedResponse()
        {
            Console.WriteLine("Http Response Attribute :");
            Console.WriteLine($"Http Version: {_httpVersion}");
            Console.WriteLine($"Status Code: {_statusCode}");
            Console.WriteLine($"Status reason phrase: {_statusReasonPhrase}");
            foreach(var keys in _responseKeyValuePair.Keys)
            {
                Console.WriteLine($"{keys} : {_responseKeyValuePair[keys]}");
            }
        }
    }
}
