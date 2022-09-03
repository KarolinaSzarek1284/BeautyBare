using BeautyBareAPI.Models;

namespace BeautyBareAPI.Services
{
    public interface IMakeUpBagService
    {
        public void AddItemToBag(int id);
        public MakeUpBagItemDto GetItemById(int bagId, int itemId);
        public List<MakeUpBagItemDto> GetItems(int bagId);
        public void RemoveItemFromBag(int bagId, int itemId);
        public void RemoveAll(int bagId);
    }
}
