using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.State;

namespace WebAppDemo.IMappers;

public interface IStateMapper
{
    GetStateDto Map(State state);
    List<GetStateDto> Map(List<State> states);
    State Map(CreateStateDto createStateDto);
    State Map(UpdateStateDto updateStateDto);
}
