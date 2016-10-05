using FluentWebRequester.Data;
using FluentWebRequester.WebRequester;
using FluentWebRequester.WebRequester.Impl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentWebRequester
{
    class Program
    {

        static void Main(string[] args)
        {
            // Some examples...

            // retrieve all customers
            var customers = RequestBuilder.Get()
                                        .AddUrl("http://www.mysite.com/api/customer")
                                        .Send<IEnumerable<CustomerData>>();

            // add a customer and get the customer added with an Id
            var customer = RequestBuilder.Post()
                                        .AddUrl("http://www.mysite.com/api/customer")
                                        .AddParameters("name", "Sponge")
                                        .AddParameters("firsname", "Bob")
                                        .Send<CustomerData>();

            // get string content
            var stringContent = RequestBuilder.Get()
                                            .AddUrl("http://www.mysite.com/customPage")
                                            .GetContent();

            // send CSV content with Post method
            var sendCsvStatusCode = RequestBuilder.PostCsv()
                                                .AddUrl("http://www.mysite.com")
                                                .AddParameters("KEY", "lastname;firstname") // headers
                                                .AddParameters("VALUE1", "sponge;bob") // values
                                                .AddParameters("VALUE2", "star;patrick")
                                                .CheckStatus();

            // authentication example (need to implement Authentication as you like)
            var authToken = RequestBuilder.Get()
                                            .AddUrl("http://www.mysite.com/auth")
                                            .AddParameters("login", "lionel")
                                            .AddParameters("password", "pouet")
                                            .Send<Authentication>();

            // check only status code and pass Authentication token
            var statusCode = RequestBuilder.Delete()
                                            .AddUrl("http://www.mysite.com/customer")
                                            .AddAuthToken(authToken)
                                            .AddParameters("id", $"customer.Id")
                                            .CheckStatus();
        }
    }
}
