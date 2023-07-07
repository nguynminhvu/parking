using Firebase.Database;
using Firebase.Database.Query;
using Parking.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.DAO
{
    public class OwnerDAO
    {
        private static OwnerDAO instance;
        private static List<DTO.Owner> listOwner= new List<DTO.Owner> ();
        private FirebaseClient clientDatabase;
       // private FirebaseApp
        public static OwnerDAO Instance { get { if (instance == null) { instance = new OwnerDAO(); }return instance; } set => instance = value; }
        public OwnerDAO() {
            clientDatabase = new FirebaseClient("https://parking-c17f2-default-rtdb.firebaseio.com");
        }   

        public async Task<List<DTO.Owner>> GetOwnerStatusRequest()
        {
            try
            {
                var dataSnapshot = await clientDatabase.Child("Owner").OnceAsync<DTO.Owner>();
                if (dataSnapshot != null)
                {
                    if (listOwner != null)
                    {
                        listOwner = new List<DTO.Owner>();
                    }
                    foreach (var item in dataSnapshot)
                    {
                        listOwner.Add(item.Object);
                    }
                    return listOwner.Where(x => x.Status.Equals("Request")).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public async void UpdateOwner(DTO.Owner oo)
        {
            await clientDatabase.Child("Owner").Child($"{oo.Id}").PutAsync(oo);
        }

    }
}
