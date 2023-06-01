﻿namespace Forum.App.Common
{
	public class EntityValidation
	{
		public static class Post
		{
			public const int TitleMinLength = 10;
			public const int TitleMaxLength = 50;
			public const int ContentMinLength = 10;
			public const int ContentMaxLength = 1500;
		}
	}
}
