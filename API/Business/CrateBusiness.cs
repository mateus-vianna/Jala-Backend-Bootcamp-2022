using Shop.API.Models;

namespace Shop.API.Business;


public class CrateBusiness
{

    public CrateBusiness()
    {

    }

    public Crate AddToCart(Crate crate)
    {

        return _CrateRepository.AddToCart(crate);
    }

}