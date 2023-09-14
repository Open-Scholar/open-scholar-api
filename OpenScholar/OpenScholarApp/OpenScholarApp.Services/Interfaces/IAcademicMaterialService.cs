using OpenScholarApp.Dtos.AcademicMaterialDto;

namespace OpenScholarApp.Services.Interfaces
{
    public interface IAcademicMaterialService
    {
        Task<List<AcademicMaterialDto>> GetAll();
        Task<AcademicMaterialDto> GetById(int id);
        Task Add(AddAcademicMaterialDto addDto, string userId);
        Task Update(UpdateAcademicMaterialDto updateDto);
        Task Delete(int id);
    }
}
