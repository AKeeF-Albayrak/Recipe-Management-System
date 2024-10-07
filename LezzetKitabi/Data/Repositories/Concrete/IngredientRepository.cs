using LezzetKitabi.Data.Repositories.Abstract;
using LezzetKitabi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Data.Repositories.Concrete
{
    public class IngredientRepository : IIngredientRepository
    {
        public bool AddEntity(Ingredient entity)
        {
            MessageBox.Show("Ya mia", "Başlık", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }
    }
}
