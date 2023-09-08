using WebAppDemo.AbsenceService.DataAccess.Entities;
using WebAppDemo.AbsenceService.DataTransferObjects.State;

namespace WebAppDemo.AbsenceService.IMappers;

public interface IStateMapper
{
    GetStateDto Map(State state);
    List<GetStateDto> Map(List<State> states);
}
