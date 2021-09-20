import 'package:audioplayers/audioplayers.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:voice_platform/constants/constants.dart';

class AudioPlayerContainer extends StatefulWidget {
  final String path;

  const AudioPlayerContainer({
    Key? key,
    required this.path,
  }) : super(key: key);

  @override
  _AudioPlayerContainerState createState() => _AudioPlayerContainerState();
}

class _AudioPlayerContainerState extends State<AudioPlayerContainer> {
  AudioPlayer audioPlayer = AudioPlayer();

  Duration _duration = const Duration();
  Duration _position = const Duration();
  bool isPlaying = false;
  final List<IconData> _icons = [
    Icons.play_arrow,
    Icons.pause,
    Icons.volume_off,
    Icons.volume_mute,
    Icons.volume_down,
    Icons.volume_up,
  ];
  double volume = 1;

  @override
  void initState() {
    super.initState();
    audioPlayer.setVolume(volume);
    audioPlayer.onDurationChanged.listen((d) {
      setState(() {
        _duration = d;
      });
    });
    audioPlayer.onAudioPositionChanged.listen((p) {
      setState(() {
        _position = p;
      });
    });
    audioPlayer.setUrl(widget.path);
    audioPlayer.onPlayerCompletion.listen((event) {
      setState(() {
        _position = const Duration(seconds: 0);
        isPlaying = false;
      });
    });
  }

  Widget btnStart() {
    //isPlaying=bool;
    return IconButton(
      onPressed: () {
        if (!isPlaying) {
          audioPlayer.play(widget.path);
          setState(() {
            isPlaying = true;
          });
        } else {
          audioPlayer.pause();
          setState(() {
            isPlaying = false;
          });
        }
      },
      icon: isPlaying == false
          ? Icon(
              _icons[0],
              size: 30.0,
              color: appYellowColor,
            )
          : Icon(
              _icons[1],
              size: 30.0,
              color: appYellowColor,
            ),
    );
  }

  Widget btnVolume() {
    return IconButton(
      onPressed: () {
        if (volume > 0) {
          setState(() {
            volume = 0;
          });
          changeVolume(0);
        } else {
          setState(() {
            volume = 1;
          });
          changeVolume(1);
        }
      },
      icon: volume == 0
          ? Icon(
              _icons[2],
              size: 30.0,
              color: appYellowColor,
            )
          : volume > 0 && volume <= 0.5
              ? Icon(
                  _icons[3],
                  size: 30.0,
                  color: appYellowColor,
                )
              : volume > 0.5 && volume < 1
                  ? Icon(
                      _icons[4],
                      size: 30.0,
                      color: appYellowColor,
                    )
                  : Icon(
                      _icons[5],
                      size: 30.0,
                      color: appYellowColor,
                    ),
    );
  }

  Widget slider() {
    return SliderTheme(
      data: SliderTheme.of(context).copyWith(
        trackHeight: 14.0,
        trackShape: CustomTrackShape(),
        thumbColor: Colors.transparent,
        thumbShape: const RoundSliderThumbShape(enabledThumbRadius: 0.0, disabledThumbRadius: 0.0),
      ),
      child: Slider(
        activeColor: appYellowColor,
        inactiveColor: const Color(0xFF646464),
        value: _position.inSeconds.toDouble(),
        min: 0.0,
        max: _duration.inSeconds.toDouble(),
        onChanged: (double value) {
          setState(() {
            changeToSecond(value.toInt());
            value = value;
          });
        },
      ),
    );
  }

  Widget sliderVolume() {
    return SliderTheme(
      data: SliderTheme.of(context).copyWith(
        trackHeight: 14.0,
        trackShape: CustomTrackShape(),
        thumbColor: Colors.transparent,
        thumbShape: const RoundSliderThumbShape(enabledThumbRadius: 0.0, disabledThumbRadius: 0.0),
      ),
      child: Slider(
        activeColor: appYellowColor,
        inactiveColor: const Color(0xFF646464),
        value: volume,
        min: 0.0,
        max: 1.0,
        onChanged: (double value) {
          setState(() {
            volume = value;
          });
          changeVolume(value);
        },
      ),
    );
  }

  void changeToSecond(int second) {
    Duration newDuration = Duration(seconds: second);
    audioPlayer.seek(newDuration);
  }

  void changeVolume(double value) {
    audioPlayer.setVolume(value);
  }

  @override
  Widget build(BuildContext context) {
    String subPosition = _position.toString().split(".")[0].toString();
    String subDuration = _duration.toString().split(".")[0].toString();

    Size size = MediaQuery.of(context).size;

    return Container(
      color: appDarkColor,
      margin: EdgeInsets.only(bottom: size.height * 0.01),
      child: Row(
        children: <Widget>[
          btnStart(),
          Row(
            children: <Widget>[
              Text(
                subPosition.substring(2, subPosition.length),
                style: const TextStyle(fontSize: 12.0, color: Colors.white),
              ),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 5.0),
                width: size.width * 0.2,
                child: slider(),
              ),
              Text(
                subDuration.substring(2, subDuration.length),
                style: const TextStyle(fontSize: 12.0, color: Colors.white),
              ),
            ],
          ),
          Row(
            children: <Widget>[
              btnVolume(),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 3.0),
                width: size.width * 0.15,
                child: sliderVolume(),
              ),
            ],
          )
        ],
      ),
    );
  }
}

class CustomTrackShape extends RectangularSliderTrackShape {
  @override
  Rect getPreferredRect({
    required RenderBox parentBox,
    Offset offset = Offset.zero,
    required SliderThemeData sliderTheme,
    bool isEnabled = false,
    bool isDiscrete = false,
  }) {
    final double trackHeight = sliderTheme.trackHeight!;
    final double trackLeft = offset.dx;
    final double trackTop = offset.dy + (parentBox.size.height - trackHeight) / 2;
    final double trackWidth = parentBox.size.width;
    return Rect.fromLTWH(trackLeft, trackTop, trackWidth, trackHeight);
  }
}
