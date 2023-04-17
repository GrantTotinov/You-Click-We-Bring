using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace GrantFoods6.ViewModels
{
    public class LandingViewModel
    {
        public LandingViewModel()
        {
            Onboardings = GetObnoarding();
        }

        public List<Onboarding> Onboardings { get; set; }
        private List<Onboarding> GetObnoarding()
        {
            return new List<Onboarding>
            {
                new Onboarding { Heading = "da", Caption = "Храни с най-високо качество. С международна оценка над 4 звезди" },
                new Onboarding { Heading = "Fast Delivery", Caption = "Now you dont have to wait for delivery " },
                new Onboarding { Heading = "low prices", Caption = "prices are the best" }
            };
        }

        


}
    public class Onboarding
    {
        public string Heading { get; set;}
        public string Caption { get; set;}
    }
}
