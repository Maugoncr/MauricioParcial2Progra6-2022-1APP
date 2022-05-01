using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MauricioParcial2APP.Models;

namespace MauricioParcial2APP.ViewModels
{
    public class ActiveViewModel : BaseViewModel
    {
        public Active MyActive { get; set; }


        public ActiveViewModel()
        {
            MyActive = new Active();

        }


        // Creamos la funcion para agregar un activo


        public async Task<bool> AddActive(
                string pActiveName,
                string pActiveArea,
                decimal pActiveCost)
        {

            if (IsBusy) return false;

            IsBusy = true;

            try
            {
                MyActive.Name = pActiveName;
                MyActive.Area = pActiveArea;
                MyActive.Cost = pActiveCost;

                bool R = await MyActive.AddNewActive();


                return R;


            }
            catch (Exception)
            {
                return false;
                throw;
            }
            finally { 
            IsBusy = false;
                
            }


        }


    }
}
