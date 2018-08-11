using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<int> IDs = new List<int>();

        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
            IDs.Add(id);
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }

        [When(@"User calls AddHotel api")]
        [Given(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels=HotelsApiCaller.AddHotel(hotel);
           // hotels.Add(hotel);
        }


        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }
        [When(@"User calls GetHotelById api by '(.*)'")]
        public void WhenUserCallsGetHotelByIdApiBy(int id)
        {
            hotel = HotelsApiCaller.GetHotelById(id);
        }
        [Then(@"Hotel with id '(.*)' should be present in the response")]
        public void ThenHotelWithIdShouldBePresentInTheResponse(int id)
        {
            hotel = hotels.Find(htl => htl.Id.Equals(id));
            hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", id));
        }
        [When(@"User calls GetAllHotels")]
        public void WhenUserCallsGetAllHotels()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }
        [Then(@"Verify all added hotels are present")]
        public void ThenVerifyAllAddedHotelsArePresent()
        {
            
            for(int i = 0; i < IDs.Count; i++)
            {
                hotel = hotels.Find(htl => htl.Id.Equals(IDs[i]));
                hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", IDs[i]));
            }
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }

    }
}
