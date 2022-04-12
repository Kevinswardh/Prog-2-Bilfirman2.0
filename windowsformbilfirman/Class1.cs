using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace windowsformbilfirman
{
    public class Klassbibliotek
    {

        //  VOLVO KALKYL KOMBINATION
        public static decimal Volvokombi2021()      //Volvo 2021
        {
            int volvopris = 160000;
            decimal procentåtta = 0.8m;             // 80%             
            int årsmodelltjugoett = 40000; 
            decimal kombination = (volvopris + årsmodelltjugoett) * procentåtta;
            return kombination;
        }
        public static decimal Volvokombi2020()     // Volvo 2020
        {
            int volvopris = 160000;
            decimal procentsju = 0.7m;              // 70%
            int årsmodelltjugotjugo = 30000;
            decimal kombination = (volvopris + årsmodelltjugotjugo) * procentsju;
            return kombination;
        }
        public static decimal Volvokombi2019()     // Volvo 2019
        {
            int volvopris = 160000;
            decimal procentsex = 0.6m;              // 60%
            int årsmodelltjugonitton = 20000;
            decimal kombination = (volvopris + årsmodelltjugonitton) * procentsex;
            return kombination;
        }
        public static decimal Volvokombi2018()     // Volvo 2018
        {
            int volvopris = 160000;
            decimal procentfem = 0.5m;
            int årsmodelltjugoarton = 10000;
            decimal kombination = (volvopris + årsmodelltjugoarton) * procentfem;
            return kombination;
        }
        //   KALKYL KOMBINATION





        public static void startaup(ArrayList användarnamn, ArrayList lösenord, ArrayList tid, string S, bool loggain, int ID)
        {
            
            if (loggain == true)
            {

             
            }
        }
      
    }
}
