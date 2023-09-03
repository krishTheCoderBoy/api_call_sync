using System;
using System.IO;
using System.Net;

public class ApiCaller
{
    public string MakeApiCall(string apiUrl)
    {
        try
        {
            // Create a web request to the API URL
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);

            // Set the HTTP method to GET
            request.Method = "GET";

            // Get the response from the API
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Check if the response status code indicates success
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    // Read the response content
                    using (Stream responseStream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(responseStream))
                    {
                        string responseBody = reader.ReadToEnd();
                        return responseBody;
                    }
                }
                else
                {
                    Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                    return null;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle exceptions, log errors, or throw custom exceptions as needed.
            Console.WriteLine($"Error: {ex.Message}");
            return null;
        }
    }
}
