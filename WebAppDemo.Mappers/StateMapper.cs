using Riok.Mapperly.Abstractions;
using WebAppDemo.DataAccess.Entities;
using WebAppDemo.DataTransferObjects.State;
using WebAppDemo.IMappers;

namespace WebAppDemo.Mappers;

[Mapper]
public partial class StateMapper : IStateMapper
{
    public partial GetStateDto Map(State state);
    public partial List<GetStateDto> Map(List<State> states);
    public partial State Map(CreateStateDto createStateDto);
    public partial State Map(UpdateStateDto updateStateDto);
}
