using ReminderService.Enitities;
using ReminderService.Exceptions;
using ReminderService.Repository;

namespace ReminderService.Services
{
    public class reminderService : IreminderService
    {
        private IReminderRepo reminderRepository;

        public reminderService(IReminderRepo repo)
        {
            reminderRepository = repo;
        }

        public Reminder CreateReminder(Reminder reminder)
        {
            try
            {
                var result = reminderRepository.CreateReminder(reminder);
                if (result == null)
                {
                    throw new ReminderNotCreatedException("This reminder already exists");
                }

                return result;
            }
            catch (ReminderNotCreatedException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteReminder(string reminderId)
        {
            try
            {
                var result = reminderRepository.DeleteReminder(reminderId);
                if (!result)
                {
                    throw new ReminderNotFoundException("This reminder id not found");
                }

                return result;
            }
            catch (ReminderNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Reminder> GetAllRemindersByUserId(string userId)
        {
            try
            {
                var result = reminderRepository.GetAllRemindersByUserId(userId);
                if (result == null)
                {
                    throw new ReminderNotFoundException();
                }

                return result;
            }
            catch (ReminderNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Reminder GetReminderById(string reminderId)
        {
            try
            {
                var result = reminderRepository.GetReminderById(reminderId);
                if (result == null)
                {
                    throw new ReminderNotFoundException("This reminder id not found");
                }

                return result;
            }
            catch (ReminderNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateReminder(string reminderId, Reminder reminder)
        {
            try
            {
                var result = reminderRepository.UpdateReminder(reminderId, reminder);
                if (!result)
                {
                    throw new ReminderNotFoundException("This reminder id not found");
                }

                return result;
            }
            catch (ReminderNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
