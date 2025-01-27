public interface ITravelStrategy
{
    void Travel();
}

public class CarStrategy : ITravelStrategy
{
    public void Travel() => Console.WriteLine("Traveling by Car.");
}

public class TrainStrategy : ITravelStrategy
{
    public void Travel() => Console.WriteLine("Traveling by Train.");
}

public class PlaneStrategy : ITravelStrategy
{
    public void Travel() => Console.WriteLine("Traveling by Plane.");
}

// 컨텍스트 클래스 (전략을 사용하는 클래스)
public class TravelContext
{
    private ITravelStrategy _strategy;

    public TravelContext(ITravelStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ITravelStrategy strategy) => _strategy = strategy;

    public void ExecuteStrategy() => _strategy.Travel();
}

public class Program
{
    public static void Main(string[] args)
    {
        // 자동차로 여행
        var travelContext = new TravelContext(new CarStrategy());
        travelContext.ExecuteStrategy();

        // 기차로 여행
        travelContext.SetStrategy(new TrainStrategy());
        travelContext.ExecuteStrategy();

        // 비행기로 여행
        travelContext.SetStrategy(new PlaneStrategy());
        travelContext.ExecuteStrategy();

      // 하나의 인터페이스를 통해 다양한 전략을 독립적으로 정의하고, 필요에 따라 연동하거나 교체
      // 결제 모듈, 사용자 그룹별 인증방식 등등 
    }
}
