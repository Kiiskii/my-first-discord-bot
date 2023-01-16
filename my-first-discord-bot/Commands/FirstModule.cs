using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace my_first_discord_bot.Commands
{
	public class FirstModule : BaseCommandModule
	{
		[Command("greet")]
		public async Task GreetCommand(CommandContext ctx)
		{
			await ctx.RespondAsync("Ayo wassup!");
		}
		[Command("domi")]
		public async Task DomiCute(CommandContext ctx)
		{
			await ctx.RespondAsync("Yes, Domi is very cute.");
		}

		// Program a command that lets the user set the bot to remind about users input by sending a personal message
		[Command("remind")]
		public async Task Remind(CommandContext ctx, int min, string subj)
		{
			await ctx.RespondAsync(Reminder(min, subj));
		}
	}
}

