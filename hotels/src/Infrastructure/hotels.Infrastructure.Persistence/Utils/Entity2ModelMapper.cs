using hotels.Application.Models.HotelModels;
using hotels.Application.Models.UserModels;
using hotels.Infrastructure.Persistence.Entities;
using System.Text.Json;

namespace Hotels.Infrastructure.Persistence.Utils;

public class Entity2ModelMapper
{
    public static UserModel User(UserEntity userEntity)
    {
        var userModel = new UserModel()
        {
            UserId = userEntity.user_id,
            Login = userEntity.login,
            PasswordHash = userEntity.password_hash
        };
        return userModel;
    }

    public static UserInfoModel UserInfo(UserInfoEntity userInfoEntity)
    {
        var userInfoModel = new UserInfoModel()
        {
            Birthday = userInfoEntity.birthday,
            Email = userInfoEntity.email,
            FirstName = userInfoEntity.first_name,
            LastName = userInfoEntity.last_name,
            Passport = userInfoEntity.passport,
            Phone = userInfoEntity.phone,
            UserId = userInfoEntity.user_id,
            UserInfoId = userInfoEntity.user_info_id,
        };
        return userInfoModel;
    }

    public static HotelModel Hotel(HotelEntity hotelEntity)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            ReadCommentHandling = JsonCommentHandling.Skip
        };
        var hotelModel = new HotelModel()
        {
            HotelId = hotelEntity.hotel_id,
            HotelChainId = hotelEntity.hotel_chain_id,
            LocationId = hotelEntity.location_id,
            Name = hotelEntity.name,
            Stars = hotelEntity.stars,
            HotelManager = hotelEntity.hotel_manager,
            Phone = hotelEntity.phone,
        };
        if (!string.IsNullOrEmpty(hotelEntity.catering))
        {
            try
            {
                hotelModel.Catering = JsonSerializer.Deserialize<List<string>>(hotelEntity.catering);
            }
            catch (JsonException)
            {
                // Console.WriteLine($"Error parsing Catering property: {ex}");
                hotelModel.Catering = new List<string>();
            }
        }
        else
        {
            hotelModel.Catering = new List<string>();
        }
        return hotelModel;
    }
    
    public static HotelChainModel HotelChain(HotelChainEntity hotelChainEntity)
    {
        var hotelChainModel = new HotelChainModel()
        {
            HotelChainId = hotelChainEntity.hotel_chain_id,
            Name = hotelChainEntity.name,
            HotelNumber = hotelChainEntity.n_hotels,
            HotelChainManager = hotelChainEntity.manager
        };
        return hotelChainModel;
    }

    public static LocationModel Location(LocationEntity locationEntity)
    {
        var locationModel = new LocationModel()
        {
            LocationId = locationEntity.location_id,
            Country = locationEntity.country,
            City = locationEntity.city,
            Street = locationEntity.street,
            BuildingNumber = locationEntity.building,
            Index = locationEntity.index
        };
        return locationModel;
    }

    public static ReservationModel Reservation(ReservationEntity reservationEntity)
    {
        var reservationModel = new ReservationModel()
        {
            ReservationId = reservationEntity.reservation_id,
            Catering = JsonSerializer.Deserialize<List<string>>(reservationEntity.catering),
            DateIn = reservationEntity.checkin,
            DateOut = reservationEntity.checkout,
            HotelId = reservationEntity.hotel_id,
            SuiteId = reservationEntity.suit_id,
            UserId = reservationEntity.user_id
        };
        return reservationModel;
    }
    
    public static SuiteModel Suite(SuiteEntity suiteEntity)
    {
        var suitModel = new SuiteModel()
        {
            SuiteId = suiteEntity.suit_id,
            HotelId = suiteEntity.hotel_id,
            Name = suiteEntity.name,
            BasePrice = suiteEntity.base_price,
            NSuits = suiteEntity.n_suits,
            Description = suiteEntity.description,
            MaxOccupancy = suiteEntity.max_occupancy
        };
        return suitModel;
    }
}