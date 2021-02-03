using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooRepository.Interfaces
{
    public interface ICollaboratorRepository
    {
        public string AddCollaborator(CollaboratorModel model);
    }
}
