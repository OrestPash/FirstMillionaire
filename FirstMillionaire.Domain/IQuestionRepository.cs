using FirstMillionaire.Domain.Entities;
using FirstMillionaire.Domain.Enums;

namespace FirstMillionaire.Repositories
{
    public interface IQuestionRepository
    {
        Question GetQuestionByComplexity(Complexity complexity);
    }
}
