﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAway.Basket.Dtos;
using TakeAway.Basket.LoginServices;
using TakeAway.Basket.Services;

namespace TakeAway.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController ( IBasketService basketService, ILoginService loginService )
        {
            _basketService = basketService;
            _loginService = loginService;
        }
        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail ()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> SaveMyBasket ( BasketTotalDto basketTotalDto )
        {
            basketTotalDto.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Changes made to the cart are saved.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBasket ()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Chart Deleted");
        }
    }
}
