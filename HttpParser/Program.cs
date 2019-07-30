using System.IO;

namespace HttpParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var requestParser = new RequestParser();
            var responseParser = new ResponseParser();
            var requestData = File.ReadAllLines(@"Data\RequestData.txt");
            var responseData = File.ReadAllLines(@"Data\ResponseData.txt");

            requestParser.ParseRequestData(requestData);
            requestParser.GetParsedRequest();

            responseParser.ParseResponseData(responseData);
            responseParser.GetParsedResponse();
        }
    }
}
