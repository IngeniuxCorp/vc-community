using System;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Content;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Ingeniux.OracleSoa.Test
{
    /// <summary>
    /// Summary description for OracleCustomerAccountTest
    /// </summary>
    [TestClass]
    public class OracleCustomerAccountTest
    {
        private string restServiceUrl = @"http://test-clontech.clon.itciss.com/webservices/rest/";
        private string serviceAlias = @"CustomerAccountContact";

        [TestMethod]
        public void TestMethod1()
        {
            string serviceOperation = @"get_cust_acct_contact_bo";

            string requestUrl = Url.Combine(restServiceUrl, serviceAlias, serviceOperation, "/");

            using (var client = new HttpClient(new HttpClientHandler { Credentials = new NetworkCredential("neggen", "inGen1616") }))
            {
                client.DefaultRequestHeaders.Accept.ParseAdd("application/json");
                client.DefaultRequestHeaders.AcceptLanguage.ParseAdd("en-US");
                client.DefaultRequestHeaders.AcceptEncoding.ParseAdd("gzip, deflate");
                var jsonContent = new CapturedJsonContent(@"{
                    ""GET_CUST_ACCT_CONTACT_BO_Input"": {
                        ""@xmlns"": ""http://test-clontech.clon.itciss.com/webservices/rest/CustomerAccountContact/"",
                        ""RESTHeader"": {
                            ""@xmlns"": ""http://xmlns.oracle.com/apps/fnd/rest/header"",
                            ""Responsibility"":""SYSTEM_ADMINISTRATOR"",
                            ""RespApplication"":""SYSADMIN"",
                            ""SecurityGroup"":""STANDARD"",
                            ""NLSLanguage"":""AMERICAN"",
                            ""Org_Id"":""0""
                        },
                        ""InputParameters"": {
                            ""P_CUST_ACCT_CONTACT_ID"":""11045"",
                            ""P_CUST_ACCT_CONTACT_OS"":"""",
                            ""P_CUST_ACCT_CONTACT_OSR"":""""
                        }
                    }
                }");
                
                jsonContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var responseMessage = client.PostAsync(requestUrl, jsonContent).Result;
                var responseString = responseMessage.Content.ReadAsStringAsync().Result;

                var responseObj = JsonConvert.DeserializeObject(responseString);

                Assert.IsNotNull(responseObj);
            }
            
            //dynamic d = restServiceUrl
            //    .AppendPathSegment(serviceAlias)
            //    .AppendPathSegment(serviceOperation)
            //    .AppendPathSegments("/")
            //    .WithBasicAuth("neggen", "inGen1616")
            //    .WithHeader("Accept", "application/json")
            //    .WithHeader("Accept-Language", "en-US")
            //    .WithHeader("Accept-Encoding", "gzip, deflate")
            //    .PostStringAsync(@"{
            //        ""GET_CUST_ACCT_CONTACT_BO_Input"": {
            //            ""@xmlns"": ""http://test-clontech.clon.itciss.com/webservices/rest/CustomerAccountContact/"",
            //            ""RESTHeader"": {
            //                ""@xmlns"": ""http://xmlns.oracle.com/apps/fnd/rest/header"",
            //                ""Responsibility"":""SYSTEM_ADMINISTRATOR"",
            //                ""RespApplication"":""SYSADMIN"",
            //                ""SecurityGroup"":""STANDARD"",
            //                ""NLSLanguage"":""AMERICAN"",
            //                ""Org_Id"":""0""
            //            },
            //            ""InputParameters"": {
            //                ""P_CUST_ACCT_CONTACT_ID"":""11045"",
            //                ""P_CUST_ACCT_CONTACT_OS"":"""",
            //                ""P_CUST_ACCT_CONTACT_OSR"":""""
            //            }
            //        }
            //    }")
            //    .ReceiveJson().Result;

            //Assert.IsNotNull(d);
        }
    }
}
