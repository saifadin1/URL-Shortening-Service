using System.Text;

namespace URLShorteningService.Helpers
{
    public static class CodeGenerator
    {
        public static StringBuilder characters;
        static CodeGenerator()
        {
            characters = new StringBuilder();
            for(int i=0; i<26; i++)
            {
                characters.Append((char)('a' + i)); 
                characters.Append((char)('A' + i));
            }
            for(int i=0; i<10; i++)
            {
                characters.Append((char)('0' + i));
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
