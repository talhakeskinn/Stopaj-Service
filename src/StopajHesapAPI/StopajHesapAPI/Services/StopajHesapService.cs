using StopajHesapAPI.Models;

namespace StopajHesapAPI.Services
{
    public class StopajHesapService
    {

        public double? Calculator(ParametersModels _parameters)
        {
            if(_parameters.isNet)
            {

                double brutMatrah = _parameters.matrah / (1 - (_parameters.oran/100));
                return brutMatrah / (100*_parameters.oran);
            }
            else if(!_parameters.isNet) {
            
                return _parameters.matrah/(100*_parameters.oran);
            }
            else
            {
               return null;
            }
            

        }

   
    }
}
