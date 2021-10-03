using CommonLayer.Model.LabelModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabel(AddLabel addLabel,long userId);
    }
}
