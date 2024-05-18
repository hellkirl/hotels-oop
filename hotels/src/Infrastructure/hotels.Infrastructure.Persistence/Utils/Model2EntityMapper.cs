using hotels.Application.Models.HotelModels;
using hotels.Application.Models.UserModels;
using hotels.Infrastructure.Persistence.Entities;
using System.Text.Json;

namespace Hotels.Infrastructure.Persistence.Utils;

public class Model2EntityMapper
{
    public static UserEntity User(UserModel userModel)
    {
        var userEntity = new UserEntity
        {
            login = userModel.Login,
            password_hash = userModel.PasswordHash,
            user_id = userModel.UserId
        };
        return userEntity;
    }

    public static UserInfoEntity UserInfo(UserInfoModel userInfoModel)
    {
        var userInfoEntity = new UserInfoEntity
        {
            birthday = userInfoModel.Birthday,
            email = userInfoModel.Email,
            first_name = userInfoModel.FirstName,
            last_name = userInfoModel.LastName,
            passport = userInfoModel.Passport,
            phone = userInfoModel.Phone,
            user_id = userInfoModel.UserId,
            user_info_id = userInfoModel.UserInfoId
        };
        return userInfoEntity;
    }

    public static HotelEntity Hotel(HotelModel hotelModel)
    {
        var hotelEntity = new HotelEntity
        {
            hotel_id = hotelModel.HotelId,
            hotel_chain_id = hotelModel.HotelChainId,
            location_id = hotelModel.LocationId,
            catering = JsonSerializer.Serialize(
                hotelModel.Catering,
                new JsonSerializerOptions { WriteIndented = true }),
            name = hotelModel.Name,
            stars = hotelModel.Stars,
            hotel_manager = hotelModel.HotelManager,
            phone = hotelModel.Phone
        };
        return hotelEntity;
    }
    
    public static HotelChainEntity HotelChain(HotelChainModel hotelChainModel)
    {
        var hotelChainEntity = new HotelChainEntity
        {
            hotel_chain_id = hotelChainModel.HotelChainId,
            manager = hotelChainModel.HotelChainManager,
            name = hotelChainModel.Name,
            n_hotels = hotelChainModel.HotelNumber
        };
        return hotelChainEntity;
    }

    public static LocationEntity Location(LocationModel locationModel)
    {
        var locationEntity = new LocationEntity
        {
            location_id = locationModel.LocationId,
            country = locationModel.Country,
            city = locationModel.City,
            street = locationModel.Street,
            building = locationModel.BuildingNumber,
            index = locationModel.Index
        };
        return locationEntity;
    }

    public static ReservationEntity Reservation(ReservationModel reservationModel)
    {
        var reservationEntity = new ReservationEntity
        {
            reservation_id = reservationModel.ReservationId,
            catering = JsonSerializer.Serialize(
                reservationModel.Catering,
                new JsonSerializerOptions { WriteIndented = true }),
            checkin = reservationModel.DateIn,
            checkout = reservationModel.DateOut,
            hotel_id = reservationModel.HotelId,
            suit_id = reservationModel.SuiteId,
            user_id = reservationModel.UserId
        };
        return reservationEntity;
    }

    public static SuiteEntity Suite(SuiteModel suiteModel)
    {
        var suiteEntity = new SuiteEntity
        {
            suit_id = suiteModel.SuiteId,
            hotel_id = suiteModel.HotelId,
            name = suiteModel.Name,
            base_price = suiteModel.BasePrice,
            n_suits = suiteModel.NSuits,
            description = suiteModel.Description,
            max_occupancy = suiteModel.MaxOccupancy
        };
        return suiteEntity;
    }
}