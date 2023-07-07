using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using Owner.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;

namespace Parking.DAO
{
    public class ParkingDAO
    {
        private static ParkingDAO instance;
        IFirebaseConfig config;
        IFirebaseClient client;
        private static List<ParkingAccept> listPC = new List<ParkingAccept>();
        private static List<ParkingAcceptDetail> listPDC = new List<ParkingAcceptDetail>();
        Firebase.Database.FirebaseClient clientDatabase;
        public static ParkingDAO Instance { get {if (instance == null) { instance = new ParkingDAO(); }return instance; }private set => instance = value; }
        public ParkingDAO() {
            config = new FirebaseConfig
            {
                BasePath = "https://parking-c17f2-default-rtdb.firebaseio.com",
                AuthSecret = "5gRhWwqlg7H6jplryxbIxp7jh58TJd1YvS3NvqX0"
            };
            client = new FireSharp.FirebaseClient(config);
            clientDatabase = new Firebase.Database.FirebaseClient("https://parking-c17f2-default-rtdb.firebaseio.com");
        }  
        public async Task<List<ParkingAccept>> GetParkingRequestList()
        {
            try
            {
                var dataSnapshot = await clientDatabase.Child("Parking").OnceAsync<ParkingAccept>();
                if (dataSnapshot != null)
                {
                    if (listPC != null)
                    {
                        listPC.Clear();
                        foreach (var item in dataSnapshot)
                        {
                            listPC.Add(item.Object);
                        }
                        return listPC.Where(x=>x.Status.Equals("Request")).ToList();  
                    }
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public async Task<List<ParkingAcceptDetail>> GetParkingAcceptDetails()
        {
            try
            {
                var dataSnapShot = await clientDatabase.Child("ParkingDetail").OnceAsync<ParkingAcceptDetail>();
                if (dataSnapShot != null)
                {
                    if (listPDC != null)
                    {
                        listPDC.Clear();
                        foreach (var item in dataSnapShot)
                        {
                            listPDC.Add(item.Object);
                        }
                        return listPDC;
                    }
                }
                return null; 
            }
            catch
            {
                return null;
            }
        }
        public async void UpdateParking(ParkingAccept parkingAccept)
        {
           await clientDatabase.Child("Parking").Child($"{parkingAccept.Id}").PutAsync(parkingAccept);
        }
    }
}
