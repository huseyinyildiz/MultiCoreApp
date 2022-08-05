using System.Text;
using Microsoft.AspNetCore.Mvc;
using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.ApiServices
{
    public class ProductApiService : Controller
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductWithCategoryDto>> GetAllAsync()
        {
            IEnumerable<ProductWithCategoryDto> productDtos;
            var response = await _httpClient.GetAsync("Product");
            if (response.IsSuccessStatusCode)
            {
                productDtos =
                    JsonConvert.DeserializeObject<IEnumerable<ProductWithCategoryDto>>(
                        await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDtos = null;
            }
            return productDtos;
        }
        public async Task<ProductWithCategoryDto> AddAsync(ProductWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                proDto = JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
                return proDto;
            }
            else
            {
                return null!;
            }

        }
        public async Task<bool> Update(ProductWithCategoryDto proDto)
        {
            var stringContent =
                new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public async Task<ProductWithCategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<ProductWithCategoryDto>> GetAllWithCategoryAsync()
        {
            IEnumerable<ProductWithCategoryDto> productDtos;
            var response = await _httpClient.GetAsync("Product/categoryall");
            if (response.IsSuccessStatusCode)
            {
                productDtos =
                    JsonConvert.DeserializeObject<IEnumerable<ProductWithCategoryDto>>(
                        await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                productDtos = null;
            }
            return productDtos;
        }
        public async Task<ProductWithCategoryDto> GetByIdForDetailAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"product/{id}/category");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null;
            }
        }

    }
}
