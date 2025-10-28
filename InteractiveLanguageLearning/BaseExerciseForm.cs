using InteractiveLanguageLearning.Data;
using InteractiveLanguageLearning.Models;
using InteractiveLanguageLearning.Services;
using System.Windows.Forms;

namespace InteractiveLanguageLearning
{
    public partial class BaseExerciseForm : Form
    {
        protected Language _language;
        protected User? _user;
        protected UserService _userService;

        public BaseExerciseForm(Language language, User? user = null)
        {
            _language = language ?? throw new ArgumentNullException(nameof(language));
            _user = user;
            _userService = new UserService(); 
        }

        public BaseExerciseForm()
        {
            _language = new Language();
            _userService = new UserService(); 
        }

        protected void SaveProgress(int exerciseId, ExerciseType exerciseType, bool isCorrect)
        {
            if (_user == null)
            {
                Console.WriteLine("SaveProgress: User is NULL");
                return;
            }

            try
            {
                Console.WriteLine($"=== SaveProgress ===");
                Console.WriteLine($"ExerciseId: {exerciseId}, ExerciseType: {exerciseType}, IsCorrect: {isCorrect}");
                Console.WriteLine($"ExerciseType as string: {exerciseType.ToString()}");
                Console.WriteLine($"ExerciseType as int: {(int)exerciseType}");

                _userService.UpdateUserProgress(_user.Id, exerciseId, exerciseType, isCorrect, isCorrect ? 10 : 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in SaveProgress: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
                }
            }
        }
    }
}