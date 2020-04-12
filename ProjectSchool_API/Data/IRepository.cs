using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        //GERAL
        void add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangeAsync();

        //ALUNO
        Task<Aluno[]> GetAllAlunosAsync (bool includeProfessor);
        Task<Aluno[]> GetAlunosAsyncByProfessorId (int ProfessorId, bool includeProfessor);
        Task<Aluno> GetAlunosAsyncById (int AlunoId, bool includeProfessor);

        //PROFESSOR
        Task<Professor[]> GetAllProfessoresAsync (bool includeAluno);
        Task<Professor> GetProfessoresAsyncById (int ProfessorId, bool includeAluno);
        
    }
}