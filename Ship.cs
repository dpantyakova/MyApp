using System.Collections.Concurrent;

namespace MyApplication.Ship;

public class Ship
{
    private int VoyageId;
    private Person Captain;
    private int _currentNumber = 0;
    private string coordinate; // Возможно, стоит инициализировать переменную, чтобы избежать ошибок с null.

    private IPlaceService PlaceService = null!; // Использование null! может привести к ошибкам, если зависимость не будет установлена.
    private ISailDb SailDb = null;
    private IPassengersDb PassengersDb = null;
    private static object _sync = new object();

    public ConcurrentDictionary<int, Person> Passengers { get; set; }

    // Конструктор, создающий объект Ship.
    public Ship(Person p, int id, IPlaceService placeService, ISailDb sailDb, IPassengersDb passengersDb)
    {
        Captain = p;
        VoyageId = id;
        Passengers = new ConcurrentDictionary<int, Person>();
        PlaceService = placeService;
        SailDb = sailDb;
        PassengersDb = passengersDb;
    }

    // Метод для регистрации пассажира.
    public void RegisterPassenger(Person p)
    {
        _currentNumber++;
        // Потенциальная проблема: при параллельных вызовах метода могут возникнуть гонки. Рекомендуется использовать потокобезопасный инкремент.
        Passengers[_currentNumber] = p; // Добавляется пассажир с уникальным идентификатором.
    }

    // Метод для получения всех имен пассажиров.
    public static string GetAllPassengersNames()
    {
        var result = string.Empty;

        foreach (var passenger in Passengers)
            result += passenger.Value.FirstName; // Здесь можно добавить пробел или запятую для читаемости списка.

        return result;
    }

    // Метод для проверки координат. Потенциально небезопасный код, так как может вызвать исключение при некорректных данных.
    public async void CheckCoordinate(string coord)
    {
        Monitor.Enter(_sync);
        try
        {
            string tmp = await PlaceService.CheckCoordinates(long.Parse(coord));
            if (!coordinate.Equals(tmp))
            {
                coordinate = tmp; // Здесь можно добавить проверку на null, чтобы избежать NullReferenceException.
            }
        }
        catch (Exception e)
        {
            // Потенциальная ошибка: Monitor.Exit не вызывается в блоке catch, что может привести к блокировке.
            Monitor.Exit(_sync);
        }
    }

    // Метод для изменения данных капитана.
    public void ChangeCaptain(string fn, string ln, string doc)
    {
        Captain.FirstName = fn;
        Captain.LastName = ln;
        // Параметр 'doc' не используется, возможно, его следует удалить или использовать в логике метода.
    }

    // Метод для сохранения данных о рейсе и пассажирах в базу данных.
    public async void SetSail()
    {
        // Потенциальная проблема: метод асинхронный, но его возвращаемый тип 'void' не позволяет обрабатывать исключения.
        await SailDb.Save(VoyageId, JsonConvert.SerializeObject(Passengers));
        await PassengersDb.Save(VoyageId, Passengers);
        // Рекомендуется добавить обработку ошибок, чтобы при сбоях в сохранении данных можно было обработать исключение.
    }
}

public class Person
{
    public string PassportId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
