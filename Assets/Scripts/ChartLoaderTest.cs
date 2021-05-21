using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ChartLoader.NET.Framework;
using ChartLoader.NET.Utils;

public class ChartLoaderTest : MonoBehaviour {

    /// <summary>
    /// The current associated chart.
    /// </summary>
    public static Chart Chart;
    //public Text textObject;

    /// <summary>
    /// Enumerator for all major difficulties.
    /// </summary>
    public enum Difficulty
    {
        EasyGuitar,
        MediumGuitar,
        HardGuitar,
        ExpertGuitar,
    }

    public Difficulty difficulty;
    public float Speed;
    public Transform[] SolidNotes;
    public string Path;
    public CameraMovement CameraMovement;
    public AudioSource Music;
    public Transform StarPowerPrefab;
    public Transform SectionPrefab;
    public Transform BpmPrefab;

    private string yourAnswer;
    public Text HpText;

    //public string inputText;

    //Chart = chartReader.ReadChartFile((TextAsset)Resources.Load("myText"));
	// Use this for initialization
	void Start ()
    {
        string currentDifficulty;

        ChartReader chartReader = new ChartReader();
        //List<string> termsList = new List<string>();
		//string[] add_arr = new string[570];
        string[] words = new string[] {"[Song]", "{", "Name = Sleep Walk","Artist = Joe Satriani", "Charter = Rob",
        "Offset = 0", "Resolution = 192", "Player2 = bass", "Difficulty = 0", "Difficulty = 0", "PreviewEnd = 0", "Genre = rock",
        "MediaType = cd", "MusicStream = song.mp3", "}", "[SyncTrack]", "{", "0 = TS 1", "0 = B 124032", "192 = TS 3","192 = B 105551",
        "384 = B 105055", "768 = TS 4", "768 = B 125367", "960 = B 117217", "1152 = B 111890", "1344 = B 109481",
        "1536 = B 105465", "2112 = B 127592", "2304 = B 148169", "2496 = B 128387", "2688 = B 109481", "2880 = B 167212",
        "3072 = B 123932", "3264 = B 114510", "3456 = B 109481", "3648 = B 147064", "3840 = TS 3", "3840 = B 106519",
        "4224 = B 100239", "4416 = TS 3 3", "4416 = B 97299", "4704 = TS 6 3", "4704 = B 96000", "42720 = B 87750",
        "42912 = B 92880", "43008 = B 77899", "43104 = B 61916", "43296 = B 77762", "43488 = B 91209", "43680 = B 90888",
        "43776 = B 50008", "43872 = B 50695", "44160 = B 101277", "44256 = B 70097", "44352 = B 55184", "44448 = B 102451",
        "44640 = B 96000", "44832 = B 125201", "45024 = B 98182", "45120 = B 85336", "47328 = TS 4", "47328 = B 105172",
        "47520 = B 98749", "47616 = B 100127", "47712 = B 96000", "47904 = B 96000", "48096 = TS 3", "48096 = B 92459",
        "48288 = B 106043", "48672 = TS 4", "48672 = B 96000", "}", "[Events]", "{", "0 = E section Ambient Intro", "4704 = E section Intro",
        "9312 = E section Chorus 1A", "13920 = E section Chorus 1B", "18528 = E section Chorus 2A", "23136 = E section Chorus 2B",
        "27744 = E section Bridge A", "32352 = E section Bridge B", "36960 = E section Chorus 3A", "41568 = E section Chorus 3",
        "45024 = E section Ending", "}", "[ExpertSingle]", "{", "192 = N 0 3624", "384 = N 3 360", "384 = N 6 0", "768 = N 4 168", "768 = N 6 0", "960 = N 3 168", "960 = N 6 0", "1152 = N 4 168", "1152 = N 6 0", "1344 = N 3 168", "1344 = N 6 0", "1536 = N 2 456", "1536 = N 6 0", "2016 = N 3 72", "2016 = N 6 0", "2112 = N 4 168", "2112 = N 6 0", "2304 = N 3 168", "2304 = N 6 0", "2496 = N 2 168", "2496 = N 6 0", "2688 = N 1 552", "2688 = N 6 0", "3264 = N 4 0", "3264 = N 6 0", "3312 = N 3 0", "3312 = N 6 0", "3360 = N 2 1128", "3360 = N 6 0", "3840 = N 0 648", "3840 = S 2 864", "4512 = N 1 72", "4512 = N 3 72", "4512 = N 6 0", "4608 = N 2 72", "4608 = N 4 72", "4608 = N 6 0", "4896 = N 1 0", "4896 = N 2 0", "4920 = N 1 0", "4920 = N 3 0", "4920 = N 5 0", "4992 = N 1 0", "4992 = N 2 0", "5016 = N 1 144", "5016 = N 3 144", "5016 = N 5 0", "5280 = N 1 0", "5280 = N 2 0", "5280 = N 3 0", "5304 = N 1 144", "5304 = N 2 144", "5304 = N 4 144", "5304 = N 5 0", "5472 = N 1 0", "5472 = N 2 0", "5472 = N 3 0", "5496 = N 1 48", "5496 = N 2 48", "5496 = N 4 48", "5496 = N 5 0", "5568 = N 1 168", "5568 = N 2 168", "5568 = N 4 168", "5856 = N 0 168", "5856 = N 1 168", "6048 = N 1 168", "6048 = N 2 168", "6240 = N 0 0", "6240 = N 1 0", "6336 = N 0 0", "6336 = N 1 0", "6432 = N 0 360", "6432 = N 2 360", "6432 = N 3 360", "6816 = N 1 72", "6912 = N 2 72", "6912 = N 5 0", "7008 = N 3 0", "7008 = N 5 0", "7032 = N 4 144", "7200 = N 3 360", "7200 = N 5 0", "8160 = N 0 168", "8160 = N 1 168", "8160 = N 2 168", "8160 = S 2 672", "8352 = N 0 168", "8352 = N 1 168", "8352 = N 2 168", "8544 = N 0 0", "8544 = N 1 0", "8544 = N 2 0", "8640 = N 0 0", "8640 = N 1 0", "8640 = N 2 0", "8736 = N 0 0", "8736 = N 1 0", "8736 = N 2 0", "8760 = N 0 240", "8760 = N 2 240", "8760 = N 3 240", "8760 = N 5 0", "9312 = N 4 408", "9744 = N 3 120", "9744 = N 5 0", "9888 = N 3 552", "10848 = N 0 0", "10848 = N 1 0", "10944 = N 1 0", "10944 = N 2 0", "11040 = N 1 0", "11040 = N 2 0", "11064 = N 1 144", "11064 = N 3 144", "11064 = N 5 0", "11232 = N 1 168", "11232 = N 2 168", "11232 = N 5 0", "11424 = N 0 0", "11424 = N 1 0", "11616 = N 2 0", "11628 = N 3 0", "11640 = N 4 432", "12192 = N 3 552", "13152 = N 0 0", "13152 = N 1 0", "13248 = N 1 0", "13248 = N 2 0", "13344 = N 1 0", "13344 = N 2 0", "13392 = N 1 120", "13392 = N 3 120", "13392 = N 5 0", "13536 = N 1 168", "13536 = N 2 168", "13536 = N 5 0", "13728 = N 2 0", "13920 = N 2 0", "13968 = N 3 216", "14208 = N 2 0", "14272 = N 3 0", "14272 = N 5 0", "14336 = N 2 0", "14336 = N 5 0", "14400 = N 1 0", "14400 = N 5 0", "14496 = N 0 264", "14496 = S 2 672", "14784 = N 0 0", "14832 = N 1 0", "14880 = N 2 0", "14928 = N 3 0", "14976 = N 2 0", "15024 = N 3 0", "15072 = N 4 0", "15264 = N 3 0", "15360 = N 3 0", "15456 = N 3 0", "15552 = N 3 0", "15648 = N 1 0", "15648 = N 3 0", "15672 = N 2 144", "15672 = N 4 144", "15672 = N 5 0", "15840 = N 1 0", "15840 = N 3 0", "15864 = N 2 144", "15864 = N 4 144", "15864 = N 5 0", "16032 = N 1 0", "16032 = N 3 0", "16056 = N 2 144", "16056 = N 4 144", "16056 = N 5 0", "16224 = N 1 0", "16224 = N 3 0", "16248 = N 2 336", "16248 = N 4 336", "16248 = N 5 0", "16608 = N 1 72", "16704 = N 2 72", "16704 = N 5 0", "16800 = N 3 0", "16800 = N 5 0", "16824 = N 4 144", "16992 = N 3 360", "16992 = N 5 0", "17568 = N 0 0", "17568 = N 1 0", "17664 = N 0 0", "17664 = N 1 0", "17760 = N 0 0", "17760 = N 1 0", "17856 = N 0 0", "17856 = N 1 0", "17952 = N 0 0", "17952 = N 1 0", "17976 = N 0 528", "17976 = N 2 528", "17976 = N 5 0", "18528 = N 4 408", "18960 = N 4 0", "18984 = N 3 96", "19104 = N 3 552", "20064 = N 0 0", "20064 = N 1 0", "20064 = S 2 672", "20160 = N 1 0", "20160 = N 2 0", "20256 = N 1 0", "20256 = N 2 0", "20280 = N 1 144", "20280 = N 3 144", "20280 = N 5 0", "20448 = N 1 168", "20448 = N 2 168", "20448 = N 5 0", "20640 = N 0 0", "20640 = N 1 0", "20832 = N 3 0", "20856 = N 4 432", "21312 = N 3 0", "21360 = N 4 0", "21360 = N 5 0", "21408 = N 3 552", "22368 = N 0 0", "22368 = N 1 0", "22464 = N 1 0", "22464 = N 2 0", "22560 = N 1 0", "22560 = N 2 0", "22608 = N 1 120", "22608 = N 3 120", "22608 = N 5 0", "22752 = N 1 168", "22752 = N 2 168", "22752 = N 5 0", "22944 = N 0 0", "22944 = N 1 0", "23136 = N 2 0", "23184 = N 3 216", "23424 = N 2 0", "23488 = N 3 0", "23488 = N 5 0", "23552 = N 2 0", "23552 = N 5 0", "23616 = N 1 0", "23616 = N 5 0", "23712 = N 0 264", "24000 = N 0 0", "24048 = N 1 0", "24096 = N 2 0", "24144 = N 3 0", "24192 = N 1 0", "24208 = N 2 0", "24224 = N 3 0", "24240 = N 4 0", "24480 = N 3 0", "24576 = N 3 0", "24672 = N 3 0", "24768 = N 3 0", "24864 = N 1 0", "24864 = N 3 0", "24864 = S 2 672", "24888 = N 2 144", "24888 = N 4 144", "24888 = N 5 0", "25056 = N 1 0", "25056 = N 3 0", "25080 = N 2 144", "25080 = N 4 144", "25080 = N 5 0", "25248 = N 1 0", "25248 = N 3 0", "25272 = N 2 144", "25272 = N 4 144", "25272 = N 5 0", "25440 = N 1 456", "25440 = N 3 456", "26016 = N 0 168", "26016 = N 2 168", "26208 = N 0 168", "26208 = N 2 168", "26400 = N 0 96", "26400 = N 2 96", "26528 = N 1 0", "26528 = N 5 0", "26560 = N 2 0", "26592 = N 1 552", "26592 = N 3 552", "26592 = N 5 0", "27648 = N 0 0", "27744 = N 2 168", "27936 = N 2 360", "28320 = N 3 0", "28368 = N 4 120", "28512 = N 4 264", "28800 = N 3 0", "28848 = N 2 0", "28848 = N 5 0", "28944 = N 1 120", "29088 = N 1 360", "29472 = N 3 0", "29520 = N 4 0", "29664 = N 3 264", "29952 = N 2 0", "30000 = N 3 0", "30000 = N 5 0", "30048 = N 1 168", "30048 = N 5 0", "30240 = N 1 264", "30528 = N 0 0", "30576 = N 1 0", "30576 = N 5 0", "30672 = N 3 408", "31104 = N 0 0", "31200 = N 0 0", "31248 = N 1 216", "31248 = N 5 0", "31488 = N 3 0", "31488 = S 2 768", "31536 = N 4 0", "31584 = N 2 0", "31632 = N 3 0", "31680 = N 4 0", "31728 = N 2 0", "31776 = N 4 0", "31824 = N 3 0", "31872 = N 2 0", "31920 = N 1 0", "31968 = N 0 0", "32016 = N 3 0", "32064 = N 0 0", "32112 = N 2 0", "32160 = N 0 168", "32352 = N 2 72", "32448 = N 2 0", "32544 = N 2 360", "32928 = N 3 0", "32976 = N 4 0", "33120 = N 3 264", "33408 = N 2 0", "33456 = N 3 0", "33456 = N 5 0", "33552 = N 1 120", "33696 = N 1 360", "34080 = N 3 0", "34128 = N 4 0", "34272 = N 3 216", "34512 = N 2 0", "34656 = N 0 168", "34656 = N 1 168", "34848 = N 0 264", "34848 = N 1 264", "35232 = N 2 0", "35232 = N 3 0", "35256 = N 3 0", "35256 = N 4 0", "35256 = N 5 0", "35424 = N 2 0", "35424 = N 3 0", "35448 = N 3 0", "35448 = N 4 0", "35448 = N 5 0", "35616 = N 2 0", "35616 = N 3 0", "35640 = N 3 144", "35640 = N 4 144", "35640 = N 5 0", "35808 = N 3 0", "35808 = N 4 0", "35832 = N 0 528", "35832 = N 1 528", "35832 = N 5 0", "36480 = N 4 0", "36528 = N 3 0", "36576 = N 2 0", "36624 = N 1 0", "36672 = N 3 0", "36720 = N 2 0", "36768 = N 1 0", "36816 = N 0 0", "36864 = N 2 0", "36912 = N 1 0", "36960 = N 0 0", "37248 = N 4 168", "37440 = N 3 72", "37440 = N 5 0", "37536 = N 3 456", "38496 = N 0 0", "38496 = N 1 0", "38592 = N 1 0", "38592 = N 2 0", "38688 = N 1 0", "38688 = N 2 0", "38712 = N 1 144", "38712 = N 3 144", "38712 = N 5 0", "38880 = N 1 168", "38880 = N 2 168", "38880 = N 5 0", "39072 = N 0 0", "39072 = N 1 0", "39264 = N 4 456", "39264 = S 2 672", "39744 = N 3 72", "39840 = N 3 456", "40800 = N 0 0", "40800 = N 1 0", "40896 = N 1 0", "40896 = N 2 0", "40992 = N 1 0", "40992 = N 2 0", "41040 = N 1 120", "41040 = N 3 120", "41040 = N 5 0", "41184 = N 1 168", "41184 = N 2 168", "41184 = N 5 0", "41376 = N 0 0", "41376 = N 1 0", "41568 = N 2 0", "41616 = N 3 216", "41856 = N 2 0", "41920 = N 3 0", "41920 = N 5 0", "41984 = N 2 0", "41984 = N 5 0", "42048 = N 1 0", "42048 = N 5 0", "42144 = N 0 544", "42912 = N 3 0", "43008 = N 3 0", "43104 = N 3 0", "43296 = N 1 0", "43296 = N 3 0", "43344 = N 2 128", "43344 = N 4 120", "43344 = N 5 0", "43488 = N 1 0", "43488 = N 3 0", "43512 = N 2 144", "43512 = N 4 144", "43512 = N 5 0", "43680 = N 1 72", "43680 = N 3 72", "43680 = N 5 0", "43776 = N 0 372", "43776 = N 2 372", "43776 = N 5 0", "44160 = N 1 72", "44256 = N 2 72", "44256 = N 5 0", "44352 = N 3 0", "44352 = N 5 0", "44364 = N 4 72", "44448 = N 3 552", "44448 = N 5 0", "45024 = N 0 2280", "45072 = N 1 2232", "45120 = N 2 2184", "45168 = N 4 2136", "47328 = N 3 744", "47328 = N 6 0", "47616 = N 2 168", "47616 = N 6 0", "47808 = N 1 0", "47808 = N 6 0", "47904 = N 0 1272", "47904 = N 6 0", "48096 = N 2 552", "48096 = N 6 0", "48672 = N 4 1224", "48672 = N 6 0", "49200 = N 1 0", "49200 = N 6 0", "49248 = N 2 648", "49248 = N 6 0", "}", };

		Chart = chartReader.ParseChartText(words);
        
        currentDifficulty = RetrieveDifficulty();

        SpawnNotes(Chart.GetNotes(currentDifficulty));

        SpawnStarPower(Chart.GetStarPower(currentDifficulty));

        //SpawnSections(Chart.Sections);

        //SpawnSynchTracks(Chart.SynchTracks);

        StartSong();
	}

    /// <summary>
    /// Retrieves the string enumerator version.
    /// </summary>
    /// <returns>string</returns>
    private string RetrieveDifficulty()
    {
        string result;
        switch (difficulty)
        {
            case Difficulty.EasyGuitar:
                result = "EasySingle";
                break;
            case Difficulty.MediumGuitar:
                result = "MediumSingle";
                break;
            case Difficulty.HardGuitar:
                result = "HardSingle";
                break;
            case Difficulty.ExpertGuitar:
                result = "ExpertSingle";
                break;
            default:
                result = "ExpertSingle";
                break;
        }

        return result;
    }

    /// <summary>
    /// Spawns all sections related to this chart.
    /// </summary>
    /// <param name="events">The events to be spawned.</param>
    private void SpawnSections(Section[] events)
    {
        Transform tmp;
        foreach (Section section in events)
        {
            tmp = SpawnPrefab(SectionPrefab, 
                transform, 
                new Vector3(-2.5f, 0, section.Seconds * Speed)
                );
        }
    }

    /// <summary>
    /// Spawns a synch track.
    /// </summary>
    /// <param name="starPowers">The star power array.</param>
    private void SpawnSynchTracks(SynchTrack[] SynchTracks)
    {
        Transform tmp;
        foreach (SynchTrack synchTrack in SynchTracks)
        {
            tmp = SpawnPrefab(BpmPrefab, transform, new Vector3(3f, 0, synchTrack.Seconds * Speed));
            tmp.GetChild(0).GetComponent<TextMesh>().text = "BPM: " + (synchTrack.BeatsPerMinute / 1000) + " " + synchTrack.Measures + "/" + synchTrack.Measures;
        }
    }

    /// <summary>
    /// Spawns a star power background.
    /// </summary>
    /// <param name="starPowers">The star power array.</param>
    private void SpawnStarPower(StarPower[] starPowers)
    {
        Transform tmp;
        foreach (StarPower starPower in starPowers)
        {
            tmp = SpawnPrefab(StarPowerPrefab, transform, new Vector3(0, 0, starPower.Seconds * Speed));
            tmp.localScale = new Vector3(1, 1, starPower.DurationSeconds * Speed);
        }
    }

    /// <summary>
    /// Spawns all notes associated to the provided array.
    /// </summary>
    /// <param name="notes">Your array of notes.</param>
    private void SpawnNotes(Note[] notes)
    {
        Transform noteTmp;
        float z;

        foreach (Note note in notes)
        {
            //note.tag = "Note";
            z = note.Seconds * Speed;
            for (int i = 0; i < 4; i++)
            {
                if (note.ButtonIndexes[i])
                {
                    noteTmp = SpawnPrefab(SolidNotes[i], transform, new Vector3(i - 1.25f, 0, z));
                    noteTmp.tag = "Note";
                    Rigidbody rb = noteTmp.gameObject.AddComponent<Rigidbody>();
                    rb.useGravity = false;
                    SphereCollider sc = noteTmp.gameObject.AddComponent<SphereCollider>();
                    sc.isTrigger = true;
                    SetLongNoteScale(noteTmp.GetChild(0), note.DurationSeconds * Speed);
                    if (note.IsHOPO)
                        SetHOPO(noteTmp);
                    else
                        SetHammerOnColor(noteTmp, (note.IsHammerOn && !note.IsChord && !note.ForcedSolid));
                }
            }
        }
    }
	
    /// <summary>
    /// Starts playing the song.
    /// </summary>
    private void StartSong()
    {
        CameraMovement.Speed = Speed;
        CameraMovement.enabled = true;
        PlayMusic();
    }

    public void CheckGreen()
    {
        print("hello");
    }

    /// <summary>
    /// Plays the current song.
    /// </summary>
    private void PlayMusic()
    {
        Music.Play();
    }

    /// <summary>
    /// Spawns a prefab in world space.
    /// </summary>
    /// <param name="prefab">The prefab you would like to instantiate.</param>
    /// <param name="parent">The parent of the prefab.</param>
    /// <param name="position">The world position of the prefab.</param>
    /// <returns>Transform</returns>
    private Transform SpawnPrefab(Transform prefab, 
        Transform parent, 
        Vector3 position)
    {
        Transform tmp;

        tmp = Instantiate(prefab);
        tmp.SetParent(parent);
        tmp.localPosition = position;

        return tmp;
    }

    /// <summary>
    /// Sets the length of the long note.
    /// </summary>
    /// <param name="note">The long note to be modified.</param>
    /// <param name="length">The length of the long note.</param>
    private void SetLongNoteScale(Transform note, float length)
    {

        note.localScale = new Vector3(note.localScale.x, note.localScale.y, length);
    }

    /// <summary>
    /// Sets the note color brighter if it is a hammer on.
    /// </summary>
    /// <param name="note">The note you would like to edit.</param>
    /// <param name="isHammerOn">Is the current note a hammer on?</param>
    private void SetHammerOnColor(Transform note, bool isHammerOn)
    {
        SpriteRenderer re;
        Color color;
        if (isHammerOn)
        {
            re = note.GetComponent<SpriteRenderer>();
            color = re.color;
            re.color = new Color(color.r + 0.75f, color.g + 0.75f, color.b + 0.75f);
        }
    }

    /// <summary>
    /// Sets the note to be HOPO note.
    /// </summary>
    /// <param name="note">The note you would like to edit.</param>
    private void SetHOPO(Transform note)
    {
        SpriteRenderer re;
        Color color;
        re = note.GetComponent<SpriteRenderer>();
        color = re.color;
        re.color = new Color(0.75f, 0, 0.75f);

    }
}
