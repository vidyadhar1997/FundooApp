﻿using FundooModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooManager.Interface
{
    public interface ICollaboratorManager
    {
        public string AddCollaborator(CollaboratorModel model);
    }
}
