using CommonLayer.Model.LabelModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        bool AddLabel(AddLabel addLabel,long userId);
        bool EditLabel(EditLabel editLabelModel, long labelId);
    }
}
