using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MauricioParcial2APP.Models
{
    public class Active
    {

        public RestRequest request { get; set; }

        const string mimetype = "application/json";

        const string contentType = "Content-Type";



        public int IdActive { get; set; }
        public string Name { get; set; }
        public string Area { get; set; }
        public decimal Cost { get; set; }


        public Active()
        {
            request = new RestRequest();
        }


        public async Task<bool> AddNewActive()
        {

            bool R = false;

            try
            {
                //
                string FinalApiRoute = CnnToAPI.ProductiorRoute + "Actives";  // puede que falte el /

                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Post);



                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                //serializar esta clase para pasarla en el body

                string SerializedClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerializedClass, mimetype);

                //esto envia la consulta al api y recibe una respuesta que debemos leer
                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;


                if (statusCode == HttpStatusCode.Created)
                {
                    R = true;


                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }

            return R;
        }




        public async Task<ObservableCollection<Active>> GetActives()
        {

            try
            {

                string routeSufix = string.Format("Actives");

                string FinalApiRoute = CnnToAPI.ProductiorRoute + routeSufix;


                RestClient client = new RestClient(FinalApiRoute);

                request = new RestRequest(FinalApiRoute, Method.Get);


                //agregar la info de seguridad, en este caso api key

                request.AddHeader(CnnToAPI.ApiKeyName, CnnToAPI.ApiKeyValue);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                var QList = JsonConvert.DeserializeObject<ObservableCollection<Active>>(response.Content);



                if (statusCode == HttpStatusCode.OK)
                {
                    return QList;
                }
                else
                {
                    return null;
                }


            }
            catch (Exception ex)
            {
                string msg = ex.Message;

                throw;
            }





        }




    }
}
