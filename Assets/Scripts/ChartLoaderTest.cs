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
        string[] words = new string[] {"[Song]", "{", "Name = Sleep Walk","Artist = Joe Satriani"};

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
            z = note.Seconds * Speed;
            for (int i = 0; i < 4; i++)
            {
                if (note.ButtonIndexes[i])
                {
                    noteTmp = SpawnPrefab(SolidNotes[i], transform, new Vector3(i - 1.25f, 0, z));
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
