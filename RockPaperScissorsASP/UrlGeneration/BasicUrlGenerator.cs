using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RockPaperScissorsASP.UrlGeneration
{
    public class BasicUrlGenerator : IGameUrlGenerator
    {
        private List<char> _url;

        private Dictionary<int, char> _dictionary;

        public BasicUrlGenerator()
        {
            Initialize();
        }

        private void Initialize()
        {
            _dictionary = new Dictionary<int, char>();

            var generator = new NumberRangeGenerator();

            int arrIndex = 0; // represents index of char in Dictionary

            // 48-57: 0-9
            // 65-90: A-Z
            // 97-122: a-z

            var arr = generator.GetArrayInts(97, 122);
            AppendToDictionary(arr, ref arrIndex);
            arr = generator.GetArrayInts(65, 90);
            AppendToDictionary(arr, ref arrIndex);
            arr = generator.GetArrayInts(48, 57);
            AppendToDictionary(arr, ref arrIndex);

            _url = new List<char>();
        }

        private void AppendToDictionary(IEnumerable<int> target, ref int arrIndex)
        {
            foreach (var i in target)
            {
                _dictionary.Add(arrIndex, (char) i);
                arrIndex++;
            }
        }

        public string GetUrl(int gameId)
        {
            var urlIndices = new List<int>()
            {
                0, 0, 0
            };

            for (int i = 0; i < gameId; i++)
            {
                IterateUrlIndices(urlIndices);
            }

            string url = "";

            foreach (var i in urlIndices)
            {
                url += _dictionary[i];
            }

            return url;

            //_url = new List<char>();
            //UpdateUrl(gameId);

            //string url = "";
            //foreach (var c in _url)
            //{
            //    url += c;
            //}

            //return url;
        }

        private void IterateUrlIndices(List<int> urlIndices)
        {
            if (urlIndices.Count == 0)
            {
                throw new InvalidOperationException("urlIndices collection is empty.");
            }

            int index = 0;

            urlIndices[index]++;

            while (urlIndices[index] == _dictionary.Count)
            {
                urlIndices[index] = 0;

                index++;

                if (index == urlIndices.Count)
                {
                    urlIndices.Add(0);
                }
                else
                {
                    urlIndices[index]++;
                }
            }
        }

        //private void UpdateUrl(int id)
        //{
        //    if (id < 0)
        //    {
        //        return;
        //    }

        //    int x = id % 62;

        //    _url.Add(_dictionary[x]);

        //    id -= 62;

        //    UpdateUrl(id);
        //}

        private void UpdateUrl(int id)
        {
            while (true)
            {
                if (id < 0)
                {
                    return;
                }

                int x = id % 62;

                _url.Add(_dictionary[x]);

                id -= 62;
            }
        }

    }
}