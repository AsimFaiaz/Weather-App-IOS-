using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;

using System.Threading.Tasks;


//=============================================
//Reference : API statement
//Purpose: ASYNC Http request and successfully get the Weather Data by using the API url and the API key gets
//         from open weather map and show the succesful or error message after executing the code.
//Date: 31st Oct 2020 but updated that time to time while working on the code
//Source: github
//Author: Oludayo Alli / DevCrux
//url: https://github.com/devcrux/CompleteWeatherApp
//Adaption: I checked Microsoft Xamarin form weather app and so many videos on youtube. Almost all the
//          videos showing the same process and nothing to change in there. I found that one easy to understand.
//=============================================


namespace TheweatherAppcXamarin
{
    public class APIStatements
    {

            public static async Task<ApiReplyBack> Get(string url, string APIKey = null)

            {
                using (var Httpclient = new HttpClient())
                {
                    if (!string.IsNullOrWhiteSpace(APIKey))
                        Httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", APIKey);

                    var request = await Httpclient.GetAsync(url);

                    if (request.IsSuccessStatusCode)
                    {
                        return new ApiReplyBack { Response = await request.Content.ReadAsStringAsync() };
                    }
                    else
                        return new ApiReplyBack { ErrorMessage = request.ReasonPhrase };
                }
            }
        }

    //=============================================
    // End reference
    //=============================================



    //=============================================
    //Reference : API statement
    //Purpose: This is pretty straight forward class and I leant that in my other course. The source video exactly did the thih
    //          what i know. So unsure reference that or not.
    //Date: 31st Oct 2020 but updated that time to time while working on the code
    //=============================================


    public class ApiReplyBack
        {

        //Response to the APIStatement

            //Check where it is successful or not.
            //If the error message is not null that mean not successful.
            public bool Successful => ErrorMessage == null;

            //Error message
            public string ErrorMessage { get; set; }

            //JSON string
            public string Response { get; set; }
        }
    }


