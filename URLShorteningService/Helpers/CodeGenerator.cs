using System.Text;

namespace URLShorteningService.Helpers
{
    public static class CodeGenerator
    {
        static StringBuilder characters;
        static CodeGenerator()
        {
            characters = new StringBuilder();
            for(int i=0; i<26; i++)
            {
                characters.Append('a' + i);
                characters.Append('A' + i);
            }
            for(int i=0; i<10; i++)
            {
                characters.Append('0' + i);
            }
        }
        public static StringBuilder Generate()
        {
            Random random = new Random();
            StringBuilder code = new StringBuilder();
            for(int i=0; i<6; i++)
            {
                code.Append(characters[random.Next() % characters.Length]);
            }
            return code;
        }
    }
}
