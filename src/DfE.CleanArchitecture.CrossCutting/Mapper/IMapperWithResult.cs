namespace DfE.CleanArchitecture.Common.CrossCutting.Mapper;
public interface IMapperWithResult<in TMapFrom, TMapTo>
{
    /// <summary>
    /// Defines the method call for mapping one type to another.
    /// </summary>
    /// <param name="input">
    /// The type to map from.
    /// </param>
    /// <returns>
    /// The type to map to.
    /// </returns>
    IMappedResult<TMapTo> Map(TMapFrom input);
}
