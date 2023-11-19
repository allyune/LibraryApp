using System;
namespace Library.Presentation.Interfaces
{
	public interface ICommand
	{
		void Execute();
		string getTitle();
    }	
}

