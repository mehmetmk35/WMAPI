using Microsoft.AspNetCore.Identity;

namespace DepoYazılımAPI.Domin.Entity.Identity
{
    public class AppUser:IdentityUser<string>
    {

        //kendimiz IdentityUser sınıfından olmayan  alanlar var ise ekliyoruz 
        public string NameSurname { get; set; } 
    }
}
