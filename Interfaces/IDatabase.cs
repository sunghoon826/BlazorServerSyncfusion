namespace BlazorServerSyncfusion.Interfaces
{
    public interface IDatabase<T> // 다른 데이터베이스도 들어오게 제네릭설정
    {
        //테이블 전체 데이터 조회
        Task<List<T>> GetAsync();

        //Id로 데이터 조회
        T GetDetail(int? id);
    }
}
