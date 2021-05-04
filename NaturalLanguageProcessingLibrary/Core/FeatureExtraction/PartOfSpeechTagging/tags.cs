using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaturalLanguageProcessingLibrary.Core.FeatureExtraction.PartOfSpeechTagging
{


    public class TagInterpreter {
        public string toText(Tag[] tags, string[] words)
        {
            string[] txt = new string[tags.Length];
            int i = 0;
            foreach (Tag tag in tags)
            {
                txt[i] = words[i]+"\\"+tag.ToString();
                i += 1;
            }
            return String.Join(" ", txt);
        }
        public Tag match(string text)
        {
            Tag[] tags = (Tag[])Enum.GetValues(typeof(Tag));
            foreach(Tag tag in tags)
            {
                if(tag.ToString().Equals(text))
                {
                    return tag;
                }
            }
            return new Tag();

        }   
        public string define(Tag t)
        {
            string text = "";
            switch (t.ToString())
            {
                case "BES": text = "BES ’s as form of BE PRP$ Possessive pronoun"; break;
                case "CC": text = "CC Coordinating conjunction RB Adverb"; break;
                case "CD": text = "CD Cardinal number RBR Adverb, comparative"; break;
                case "DT": text = "DT Determiner RP Particle"; break;
                case "EX": text = "EX Existential there TO Infinitival to"; break;
                case "IN": text = "IN Preposition/ subordinating conjunction UH Interjection, filler, discourse marker"; break;
                case "JJ": text = "JJ Adjective VB Verb, base form"; break;
                case "JJR": text = "JJR Adjective, comparative VBD Verb, past tense"; break;
                case "JJS": text = "JJS Adjective, superlative VBG Verb, gerund/ present participle"; break;
                case "MD": text = "MD Modal VBN Verb, past participle"; break;
                case "NN": text = "NN Noun, singular or mass VBP Verb, non-3rd ps. sing. present"; break;
                case "NNP": text = "NNP Proper noun, singular VBZ Verb, 3rd ps. sing. present"; break;
                case "NNPS": text = "NNPS Proper noun, plural WDT Wh-determiner"; break;
                case "NNS": text = "NNS Noun, plural WP Wh-pronoun"; break;
                case "PDT": text = "PDT Predeterminer WRB Wh-adverb"; break;
                case "POS": text = "POS Possessive ending XX Partial word, POS unclear"; break;
                case "PRP": text = "PRP Personal pronoun"; break;
                default: text = "unknown"; break;
            }
            return text;
        }
    }

    public enum Tag
    {
        BES,
        CC,
        CD,
        DT,
        EX,
        IN,
        JJ,
        JJR,
        JJS,
        MD,
        NN,
        NNP,
        NNPS,
        NNS,
        PDT,
        POS,
        PRP,
        PTPd,
        RB,
        RBR,
        RP,
        TO,
        UH,
        VB,
        VBD,
        VBG,
        VBN,
        VBP,
        VBZ,
        WDT,
        WP,
        WRB,
        XX,
        UNKNOWN
    }
}
