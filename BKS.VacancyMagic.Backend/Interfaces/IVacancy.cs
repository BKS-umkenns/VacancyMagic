using BKS.VacancyMagic.Backend.Models.Auth;
using BKS.VacancyMagic.Backend.Models.Vacancy;

namespace BKS.VacancyMagic.Backend.Interfaces;

public interface IVacancy
{
    /// <summary>
    /// Базовый URL API сервиса с вакансиями
    /// </summary>
    public string? BaseUrl { get; set; }
    /// <summary>
    /// Наименование сервиса с вакансиями
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// Получение списка вакансий
    /// </summary>
    /// <param name="prompt">Строка для поиска вакансий по ключевым словам(тегам)</param>
    /// <returns></returns>
    public Task<VacancyRecordDTO?> GetDataAsync<TPrompt>(TPrompt prompt, CancellationToken ct) where TPrompt : class;
    /// <summary>
    /// Отклик на вакансию
    /// </summary>
    /// <param name="record">Вакансия на которую откликается соискатель</param>
    /// <returns>Данные об отклике</returns>
    public Task<ReplyDTO> ReplyAsync(VacancyRecordDTO record, CancellationToken ct);
    /// <summary>
    /// Получение статуса отклика на вакансию
    /// </summary>
    /// <param name="serviceReply">Данные об отклике для запроса его статуса</param>
    /// <returns>Статус отклика</returns>
    public Task<ReplyStatusDTO> GetReplyStatusAsync(ServiceReplyDTO serviceReply, CancellationToken ct);
    /// <summary>
    /// Авторизация в сервисе вакансий
    /// </summary>
    /// <param name="authRequest">Модель данных для запроса токенов авторизации</param>
    /// <returns>Авторизационный ответ с данными о токенах</returns>
    public Task<AuthResultDTO> AuthorizationAsync(AuthRequestDTO authRequest, CancellationToken ct);
}
