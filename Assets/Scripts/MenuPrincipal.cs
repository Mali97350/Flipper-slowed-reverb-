using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MenuPrincipal : MonoBehaviour
 
{
  /// Fait le son quand le bouton est cliquer, requiers le menu manager dans audioSource et le son jouer dans SonClick
  public AudioSource audioSource;   
  public AudioClip SonClick;     
  public void ClickSound()
  {
    audioSource.PlayOneShot(SonClick);
  }
  /// Permet de changer de scéne
  public void LancerPartie()
  {
    SceneManager.LoadSceneAsync("Jeux");
  }
  /// Permet d'etteindre l'app
  public void Quitter()
  {
    Debug.Log("Le jeux devrais s'etteindre la mtn tout desuite");
    Application.Quit();
  }

  [SerializeField] private AudioMixer mixeuraudio;
  [SerializeField] private Slider Slidermusic;

  public void Setvolumeson()
  {
    float Volume = Slidermusic.value;
    mixeuraudio.SetFloat("Volume", Mathf.Log10(Volume) * 20);
  }
  
}
