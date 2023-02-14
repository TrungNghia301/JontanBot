This is the basic format of the JonTan a telegram bot that team 12 built.
---------------------------------------------------
• Framework:
- Because the program is written in C# so we use .NET Framework (version used 6.0).
---------------------------------------------------
• All package include:
-Telegram.Bot:
	+ support to build a bot on Telegram;
- Htmlagilitypack: 
	+ support to build bot's "news" function;
link to find about it: html-agility-pack.net;
- Google.Apis.Calendar.v3:
	+ support to build bot's "calendar" funtion;
link to find: developers.google.com/api-client-library/dotnet/apis/calendar/v3.
- YoutubeExplode:
	+ support to build bot's "listen" funtion;
link to find: github.com/Tyrrrz/YoutubeExplode#q-are-mixed-streams-limited-at-720p-quality
---------------------------------------------------
• Something to prepare for JonTan bot:
- Text file .txt:
	+ Task file: to return task of bot can do;
	Example:

		Chào bạn JonTan là bot hỗ trợ nhóm 12 hoàn thành tập bài tập nhóm lập trình mạng
		Các chức năng mà mình hiện có:
		Xem tin tức:
		/news : hiện một tin tức bất kì
		/allnews : hiện tất cả tin tức
		Thời khóa biểu:
		/nevent : thêm sự kiện vào lịch
		/scalendar : hiện danh sách lịch
		Nghe nhạc:
		/listen
		Vui lòng chọn một yêu cầu bạn mong muốn!

	+ TaskSaveEventlist: to read value from list Event from calendar convert to Json (it may not be necessary we can remove it in code);
- Downloaded json private key:
tutorial: https://stackoverflow.com/questions/54066564/google-calendar-api-with-asp-net.
---------------------------------------------------
• Document we use to build the telebot bot:
- Create basic telebot bot:
	+ How to create a telegram bot in C# quickly?, Source:Prog.World
	link: https://prog.world/how-to-create-a-telegram-bot-in-c-quickly/;
	+ A guide to Telegram.Bot library
	link:https://telegrambots.github.io/book/1/quickstart.html
- Create contact with Google Calendar Api:
	+link: https://stackoverflow.com/questions/54066564/google-calendar-api-with-asp-net.
- And some method from https://html-agility-pack.net/
- Everything about YoutubeExplore package writed by author:Tyrrrz
	+link: https://github.com/Tyrrrz/YoutubeExplode#q-are-mixed-streams-limited-at-720p-quality
---------------------------------------------------
Thanks for reading.


---------------------------------------------------
Author: Nguyen Trung Nghia