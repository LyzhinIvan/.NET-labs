namespace Lab01
{
    /// <summary>
    /// Класс, позволяющий получать из отдельного потока информацию о прогрессе выполнения
    /// </summary>
    public class ProgressHolder
    {
        /// <summary>
        /// Текущий прогресс, устанавливается одним потоком и читается другим
        /// </summary>
        public int Progress { get; set; }
    }
}
