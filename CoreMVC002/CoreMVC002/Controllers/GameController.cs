using Microsoft.AspNetCore.Mvc;
using CoreMVC002.Models;

namespace CoreMVC002.Controllers
{
    public class GameController : Controller
    {
        private const string TempDataKey = "GameState";

        public IActionResult Index()
        {
            // 创建新的游戏实例并保存到 TempData
            var engine = new XAXBEngine();
            TempData[TempDataKey] = System.Text.Json.JsonSerializer.Serialize(engine);
            return View(engine);
        }

        [HttpPost]
        public IActionResult Guess(string guess)
        {
            if (string.IsNullOrEmpty(guess))
            {
                ModelState.AddModelError("", "請輸入一個有效的4位數字。");
                return RedirectToAction("Index");
            }

            // 从 TempData 加载游戏状态
            if (TempData[TempDataKey] is string gameState)
            {
                var engine = System.Text.Json.JsonSerializer.Deserialize<XAXBEngine>(gameState);
                engine.Guess = guess;
                engine.Result = engine.GetResult(guess);

                // 检查游戏是否结束
                if (engine.IsGameOver())
                {
                    TempData.Remove(TempDataKey); // 清除游戏状态
                    ViewBag.GameOver = true;
                }
                else
                {
                    // 保存游戏状态
                    TempData[TempDataKey] = System.Text.Json.JsonSerializer.Serialize(engine);
                }

                return View("Index", engine);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Restart()
        {
            // 清除 TempData 并重新开始游戏
            TempData.Remove(TempDataKey);
            return RedirectToAction("Index");
        }
    }
}

