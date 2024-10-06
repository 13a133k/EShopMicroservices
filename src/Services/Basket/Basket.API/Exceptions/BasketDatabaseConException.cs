namespace Basket.API.Exceptions;

public class BasketDatabaseConException(string connectionFailed) : InternalServerException(connectionFailed);